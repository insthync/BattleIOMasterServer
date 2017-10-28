﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameNetworkManagerWithMsf : GameNetworkManager
{
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        var ioGamesRoom = FindObjectOfType<IOGamesRoom>();
        if (ioGamesRoom != null)
            ioGamesRoom.ClientDisconnected(conn);
    }

    public void StartHostButQuitIfCannotListen()
    {
        if (StartHost() == null)
            Application.Quit();
    }

    public void StartServerButQuitIfCannotListen()
    {
        if (!StartServer())
            Application.Quit();
    }
}
