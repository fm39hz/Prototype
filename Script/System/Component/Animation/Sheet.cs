using Godot;

namespace Component.Animation{
    public partial class SpriteSheet : Sprite2D{
        [Signal] public delegate void AnimationFinishedEventHandler();
        private int targetDirection;
        private int currentFrame = 0;
        private double frameCounter = 0;
        public void Animate(FrameInfo frame, int direction, double relativeResponseTime, bool isLoop){
            targetDirection = direction;
            int _firstFrame = frame.Length * targetDirection;
            int _nextFrame = frame.Length * (targetDirection + 1);
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
            FrameCoords = new Vector2I(currentFrame, frame.State);
            }
        }
    }
