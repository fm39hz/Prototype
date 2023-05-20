using Godot;
using Metadata.Object;

namespace Component.Animation{
    /// <summary>
    /// Class dùng cho Sprite Sheet, chia animation theo 8 hướng
	/// </summary>
    public partial class SpriteSheet : Sprite2D{
        /// <summary>
        /// Signal được kích khi Chủ thể không loop và chạy xong animation
		/// </summary>
        [Signal] public delegate void AnimationFinishedEventHandler();
        /// <summary>
        /// Frame hiện tại
		/// </summary>
        private int currentFrame{get; set;} = 0;
        /// <summary>
        /// Bộ đếm frame thực
		/// </summary>
        private double frameCounter{get; set;} = 0;
        /// <summary>
        /// Chạy animation của Sprite Sheet Dữ liệu của đối tượng được truyền vào
        /// </summary>
        /// <param name="frameInfo">Thông tin frame hiện tại</param>
        /// <param name="objectData">Metadata của chủ thể</param>
        /// <param name="relativeResponseTime">Thời gian phản hồi tương đối</param>
        public void Animate(FrameInfo frameInfo, DynamicObjectMetadata objectData, double relativeResponseTime){
            var _direction = objectData.GetDirectionAsNumber();     //Lấy hướng nhìn của đối tượng
            var _firstFrame = frameInfo.Length * _direction++;      //Lấy frame bắt đầu của animation
            var _nextFrame = frameInfo.Length * _direction;         //Lấy frame bắt đầu của hướng kế tiếp
                if (_firstFrame <= currentFrame && currentFrame < _nextFrame){
                    frameCounter += relativeResponseTime;       //Tạo bộ đếm frame(thực)
                    }
                if (frameCounter >= 60 * relativeResponseTime / frameInfo.Speed){
                    if (currentFrame == _nextFrame - 1){
                        if (!objectData.IsLoopingAnimation){
                            EmitSignal(SignalName.AnimationFinished);
                            }
                        currentFrame = _firstFrame;             //Reset về frame bắt đầu khi tới frame cuối
                        }
                    else if (currentFrame < _nextFrame){
                        currentFrame++;                         //Tăng frame lên 1 khi chưa chạm tới frame cuối
                        }
                    frameCounter = 0;                           //Reset bộ đếm frame(thực)
                    }
                if (currentFrame < _firstFrame || currentFrame > _nextFrame){
                    currentFrame = _firstFrame;                 //Chuyển tiếp frame tới vị trí mới
                    }
            FrameCoords = new Vector2I(currentFrame, objectData.StateID);
            }
        }
    }
