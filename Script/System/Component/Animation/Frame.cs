namespace Component.Animation{
    public class FrameInfo{
        public FrameInfo(int frameNumber, double speed){
            Length = frameNumber;
            Speed = speed;
            }
        public int Length{get; set;}
        public double Speed{get; set;}
        }
    }