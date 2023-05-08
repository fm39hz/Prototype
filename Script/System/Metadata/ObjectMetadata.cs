using Godot;
using Management.Direction;

namespace Metadata.Object{
    public partial class ObjectMetadata{
        public int StateID{get; set;}
        public DirectionManager Direction{get; protected set;}
        public bool IsLoopingAnimation{get; set;}
        private int DirectionNumber;
        private Vector2 DirectionVector;
        public ObjectMetadata(){
            this.StateID = 0;
            this.Direction = new();
            this.IsLoopingAnimation = true;
            this.DirectionNumber = 0;
            this.DirectionVector = Vector2.Down;
            }
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
