using Godot;
using Component;

[Tool]
public partial class SheetComponent : Sprite2D{
    public SheetComponent(int _row, int _collum){
        Hframes = _row;
        Vframes = _collum;
        }
    private int targetDirection;
    private int currentFrame = 0;
    double frameCounter = 0;
    delegate void animationFinished();
    public void RunAnimation(FrameComponent _frame, float _speed, bool _loop){
        targetDirection = _frame.Direction;
        int firstFrame = _frame.Length * targetDirection;
        int nextFrame = _frame.Length * (targetDirection + 1);
            if (firstFrame <= currentFrame && currentFrame < nextFrame){
                frameCounter += _frame.RelativeTimeResponse;
                }
            if (frameCounter >= 60 * _frame.RelativeTimeResponse / _speed){
                currentFrame++;
                frameCounter = 0;
                }
            if (currentFrame < firstFrame || currentFrame >= nextFrame){
                if (_loop){
                    EmitSignal(nameof(animationFinished));
                    }
                currentFrame = firstFrame;
                }
            FrameCoords = new Vector2I(currentFrame, _frame.State);
        }
    }
