namespace Metadata.Animation{
    /// <summary>
    /// Chứa thông tin về frame của 1 đối tượng
    /// </summary>
    public class FrameData{
        public FrameData(int frameNumber, double speed){
            Length = frameNumber;
            Speed = speed;
            }
        /// <summary>
        /// Số frame của Animation
        /// </summary>
        /// <value></value>
        public int Length{get; set;}
        /// <summary>
        /// Tốc độ của Animation
        /// </summary>
        /// <value></value>
        public double Speed{get; set;}
        }
    }