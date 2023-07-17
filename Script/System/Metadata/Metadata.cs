using System;
using Godot;

namespace Metadata.Global;
    public partial class Metadata : Node{
        public double RelativeResponseTime { get; protected set; }
        public override void _Ready(){
            this.ProcessMode = ProcessModeEnum.Always;
            GD.Print("Metadata Ready!");
            }
        public override void _PhysicsProcess(double delta){
            this.RelativeResponseTime = Performance.GetMonitor(Performance.Monitor.TimeFps) * delta;
            }
        }   