using Godot;

namespace Metadata.Instance;
    public partial class ObjectData{
        public int StateID { get; set; }
        public DirectionData Direction { get; protected set; }
        public bool IsLoopingAnimation { get; set; }
        public bool IsFourDirection { get; set; }
        public ObjectData(){
            this.StateID = 0;
            this.Direction = new();
            this.IsLoopingAnimation = true;
            this.IsFourDirection = true;
            }
        public void SetDirection(int input){
            this.Direction.SetDirection(input);
            }
        public void SetDirection(Vector2 input){
            this.Direction.SetDirection(input);
            }
        public int GetDirectionAsNumber(){
            if (this.Direction.AsNumber > 3 && this.IsFourDirection){
                switch (this.Direction.AsNumber){
                    case 4:
                        return 1;
                    case 5:
                        return 1;
                    case 6:
                        return 3;
                    case 7:
                        return 3;
                    }
                }
            return this.Direction.AsNumber;
            }
        public Vector2 GetDirectionAsVector(){
            return this.Direction.AsVector.Normalized();
            }
        }
