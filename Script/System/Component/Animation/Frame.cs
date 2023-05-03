namespace Component.Animation{
    public class FrameInfo{
        public FrameInfo(int frameNumber, int stateNumber, double speed){
            Length = frameNumber;
            State = stateNumber;
            Speed = speed;
            }
        public int Length{get; set;}
        public int State{get; set;}
        public double Speed{get; set;}
            public static double GetRelativeResponseTime(double delta){
                return 60 * delta;
                }
        }
    }