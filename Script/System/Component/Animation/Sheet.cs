using Godot;
using Metadata.Object;

namespace Component.Animation{
    public partial class SpriteSheet : Sprite2D{
        [Signal] public delegate void AnimationFinishedEventHandler();
        private int currentFrame = 0;
        private double frameCounter = 0;
        public void Animate(FrameInfo frame, ObjectMetadata objectdata, double relativeResponseTime, bool isLoop){
            var _direction = objectdata.GetDirectionNumber();
            var _firstFrame = frame.Length * _direction++;
            var _nextFrame = frame.Length * _direction;
                if (_firstFrame <= currentFrame && currentFrame < _nextFrame){
                    frameCounter += relativeResponseTime;
                    }
                if (frameCounter >= 60 * relativeResponseTime / frame.Speed){
                    currentFrame++;
                    frameCounter = 0;
                    }
                if (currentFrame < _firstFrame || currentFrame >= _nextFrame){
                    if (!isLoop){
                        EmitSignal(SignalName.AnimationFinished);
                        return;
                        }
                    currentFrame = _firstFrame;
                    }
            FrameCoords = new Vector2I(currentFrame, objectdata.StateID);
            }
        }
    }
