using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Managers.Network;
using QFSW.QC;
using Shun_Unity_Editor;
using Unity.Netcode;
using UnityEngine;
using UnityUtilities;

public class GameManager : SingletonNetworkBehavior<GameManager>
{
    [SerializeField, ShowImmutable]private List<PlayerController> _playerControllers = new ();

    private readonly NetworkVariable<int> _playerTurn = new NetworkVariable<int>(0);
    public int PlayerTurn => _playerTurn.Value;



    public void AddPlayerController(PlayerController playerController)
    {
        _playerControllers.Add(playerController);
    }

    [Command]
    public void StartGame()
    {
        _playerControllers[PlayerTurn].PlayerTurnController.StartPreparationPhaseServerRPC();
    }
    
    public void EndCurrentPlayerTurn()
    {
        if (!_playerControllers[PlayerTurn].IsOwner) return;
        
        Debug.Log($"Player {_playerControllers[PlayerTurn].OwnerClientId} end turn");
        _playerControllers[PlayerTurn].PlayerTurnController.EndTurnServerRPC();
    }

    [ServerRpc]
    public void StartNextPlayerTurnServerRPC()
    {
        _playerTurn.Value++;
        if (PlayerTurn >= _playerControllers.Count)
        {
            _playerTurn.Value = 0;
        }
        _playerControllers[PlayerTurn].PlayerTurnController.StartPreparationPhaseServerRPC();
        
        Debug.Log($"Player {_playerControllers[PlayerTurn].OwnerClientId} start turn");

    }
    
}