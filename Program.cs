﻿using System;
using System.CodeDom;
using Terminal.Gui;

namespace MCSM;

public partial class MainProc{
    public static void Main(){
        InitServer();
        Application.Init();
        Application.Run(new MainForm());
    }
}