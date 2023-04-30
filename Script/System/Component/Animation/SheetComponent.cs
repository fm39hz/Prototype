using Godot;

namespace Component.Animation{
    public partial class SheetComponent : Sprite2D{
        private int targetDirection;
        private int currentFrame = 0;
        double frameCounter = 0;
        delegate void animationFinished();
        public void RunAnimation(FrameComponent _frame, double RelativeTimeResponse, bool _loop){
            targetDirection = _frame.Direction;
            int firstFrame = _frame.Length * targetDirection;
            int nextFrame = _frame.Length * (targetDirection + 1);
                if (firstFrame <= currentFrame && currentFrame < nextFrame){
                    frameCounter += RelativeTimeResponse;
                    }
                if (frameCounter >= 60 * RelativeTimeResponse / _frame.Speed){
                    currentFrame++;
                    frameCounter = 0;
                    }
                if (currentFrame < firstFrame || currentFrame >= nextFrame){
                    // if (_loop){
                    //     EmitSignal(nameof(animationFinished));
                    //     }
                    currentFrame = firstFrame;
                    }
                FrameCoords = new Vector2I(currentFrame, _frame.State);
            }
        }
    }
