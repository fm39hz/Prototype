using Godot;
using Metadata.Object;

namespace Component.Animation{
    public partial class SpriteSheet : Sprite2D{
        [Signal] public delegate void AnimationFinishedEventHandler();
        private int currentFrame = 0;
        private double frameCounter = 0;
        public void Animate(FrameInfo frameInfo, DynamicMetadata objectData, double relativeResponseTime){
            var _direction = objectData.GetDirectionNumber();   //Lấy hướng nhìn của đối tượng
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
