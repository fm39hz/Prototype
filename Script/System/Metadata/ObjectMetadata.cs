using Godot;
using Management.Direction;

namespace Metadata.Object{
    public partial class ObjectMetadata{
        public int StateID{get; set;} = 0;
        public DirectionManager Direction{get; protected set;} = new();
        public bool IsLoopingAnimation{get; set;}
        private int DirectionNumber = 0;
        private Vector2 DirectionVector = Vector2.Down;
        public void SetDirection(int input){
            this.DirectionNumber = input;
            this.DirectionVector = Direction.GetDirectionVector(input);
            }
        public void SetDirection(Vector2 input){
            this.DirectionVector = input;
            this.DirectionNumber = Direction.GetDirectionNumber(input);
            }
        public int GetDirectionNumber(){
            return this.DirectionNumber;
            }
        public Vector2 GetDirectionVector(){
            return this.DirectionVector;
            }
        }
    }
