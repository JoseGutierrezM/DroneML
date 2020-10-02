using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoSingleton<CanvasManager>
{
    SetUpSimulationPanel setUpSimulationPanel;
    SimulationPanel simulationPanel;
    EndSimulationPanel endSimulationPanel;
    DronePanelUI activePanel;

    SimulationManager simulationManager;

    protected override void Awake()
    {
        base.Awake();
        setUpSimulationPanel = GetComponentInChildren<SetUpSimulationPanel>(true);
        simulationPanel = GetComponentInChildren<SimulationPanel>(true);
        endSimulationPanel = GetComponentInChildren<EndSimulationPanel>(true);
        simulationPanel.gameObject.SetActive(false);
        endSimulationPanel.gameObject.SetActive(false);
        activePanel = setUpSimulationPanel;
        simulationManager = SimulationManager.GetInstance();
        SimulationManager.onSetUpSimulation += ActivateSetUpPanel;
        SimulationManager.onStartSimulation += ActivateInformationPanel;
        //SimulationManager.onEndSimulation += ActivateEndSimulationPanel;
        Drone.onLandingResult += EndSimulation;
    }

    void ChangePanel(DronePanelUI _newPanel)
    {
        activePanel.gameObject.SetActive(false);
        activePanel = _newPanel;
        _newPanel.gameObject.SetActive(true);
    }

    void ActivateSetUpPanel()
    {
        ChangePanel(setUpSimulationPanel);
    }

    void ActivateInformationPanel()
    {
        ChangePanel(simulationPanel);
    }

    void ActivateEndSimulationPanel()
    {
        ChangePanel(endSimulationPanel);
    }

    void EndSimulation(bool _landingResult)
    {
        ActivateEndSimulationPanel();
        if (_landingResult)
        {
            endSimulationPanel.Success();
        }
        else
        {
            endSimulationPanel.Failure();
        }
        simulationManager.EndSimulation();
    }
}