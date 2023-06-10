using Godot;
using Metadata.Direction;

namespace Metadata.Object;
    public partial class DynamicObjectData{
        public int StateID{get; set;}
        public DirectionData Direction{get; protected set;}
        public bool IsLoopingAnimation{get; set;}
        public DynamicObjectData(){
            this.StateID = 0;
            this.Direction = new();
            this.IsLoopingAnimation = true;
            }
        public void SetDirection(int input){
            this.Direction.SetDirection(input);
            }
        public void SetDirection(Vector2 input){
            this.Direction.SetDirection(input);
            }
        public int GetDirectionAsNumber(){
            return this.Direction.AsNumber;
            }
        public Vector2 GetDirectionAsVector(){
            return this.Direction.AsVector;
            }
        }
