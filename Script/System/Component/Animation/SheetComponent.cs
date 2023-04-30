using Godot;

namespace Component.Animation{
    public partial class SheetComponent : Sprite2D{
        private int targetDirection;
        private int currentFrame = 0;
        double frameCounter = 0;
        [Signal]
            public delegate void AnimationFinishedEventHandler();
        public void RunAnimation(FrameComponent frame, double RelativeTimeResponse, bool loop){
            targetDirection = frame.Direction;
            int _firstFrame = frame.Length * targetDirection;
            int _nextFrame = frame.Length * (targetDirection + 1);
                if (_firstFrame <= currentFrame && currentFrame < _nextFrame){
                    frameCounter += RelativeTimeResponse;
                    }
                if (frameCounter >= 60 * RelativeTimeResponse / frame.Speed){
                    currentFrame++;
                    frameCounter = 0;
                    }
                if (currentFrame < _firstFrame || currentFrame >= _nextFrame){
                    if (!loop){
                        EmitSignal(SignalName.AnimationFinished);
                        return;
                        }
                    currentFrame = _firstFrame;
                    }
            FrameCoords = new Vector2I(currentFrame, frame.State);
            }
        }
    }
