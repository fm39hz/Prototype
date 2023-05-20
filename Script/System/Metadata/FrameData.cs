namespace Metadata.Animation{
    public class FrameData{
        public FrameData(int frameNumber, double speed){
            Length = frameNumber;
            Speed = speed;
            }
        public int Length{get; set;}
        public double Speed{get; set;}
        }
    }