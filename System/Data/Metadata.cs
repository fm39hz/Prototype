using System;
using Godot;

namespace GameSystem.Data.Global;
    public partial class Metadata : Node{
		/// <summary>
		/// Trả về giá trị bằng fps * delta
		/// </summary>
		/// <returns>1 khi fps đạt ngưỡng lý tưởng</returns>
        public double RelativeResponseTime { get; private set; }
        public override void _Ready(){
            this.ProcessMode = ProcessModeEnum.Always;
            }
        public override void _PhysicsProcess(double delta){
            this.RelativeResponseTime = Performance.GetMonitor(Performance.Monitor.TimeFps) * delta;
            }
        }   