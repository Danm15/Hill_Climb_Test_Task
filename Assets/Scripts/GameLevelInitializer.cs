using System;
using System.Collections.Generic;
using Player;
using Core.Services.Updater;
using InputReader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevelInitializer : MonoBehaviour
{
    [SerializeField] private CarEntity _carEntity;
    [SerializeField] private GameUIInputView _gameUIInput;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _pauseButton;
    
    private ExternalDevicesInputReader _externalDevicesInput;
    private CarSystem _carSystem;
    private ProjectUpdater _projectUpdater;
        
    private List<IDisposable> _disposables;

    private bool _onPause;

    private void Awake()
    {
        _disposables = new List<IDisposable>();
            
        if (ProjectUpdater.Instance == null)
            _projectUpdater = new GameObject().AddComponent<ProjectUpdater>();
        else
            _projectUpdater = ProjectUpdater.Instance as ProjectUpdater;
            
        _externalDevicesInput = new ExternalDevicesInputReader();

        _carSystem = new CarSystem(_carEntity, new List<IEntityInputSource> 
        { 
            _externalDevicesInput,
            _gameUIInput
        });
        _disposables.Add(_carSystem);

        PlayerHead.OnHeadDamaged += GameOver;

    }
    private void OnDestroy()
    {
        foreach (var disposiable in _disposables)
        {
            disposiable.Dispose();
        }

        PlayerHead.OnHeadDamaged -= GameOver;
    }

    private void GameOver()
    {
        _restartButton.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(false);
    }
    
    public void Pause() => _projectUpdater.IsPaused = !_projectUpdater.IsPaused;

    public void Restart() => SceneManager.LoadScene("Scenes/MainScene");
    
}
