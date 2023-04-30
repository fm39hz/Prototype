using Godot;
using System;

namespace Component.Animation{
    public class FrameComponent{
        public FrameComponent(int _frameNumber, int _stateNumber, double _speed){
            Length = _frameNumber;
            State = _stateNumber;
            Speed = _speed;
            }
        public int Length{get; set;}
        public int State{get; set;}
        public int Direction{get; set;}
        public double Speed{get; set;}
        public void GetDirection(Vector2 _input){
            int _angleNumb = Convert.ToInt32(Math.Round(_input.Angle() / Mathf.Pi * 180));
                if (_angleNumb <= 0){
                    _angleNumb *= -1;
                    }
                else{
                    _angleNumb = -(_angleNumb - 360);
                    }
            if (_input != Vector2.Zero){
                int _temp;
                    _temp = _angleNumb / 45;
                        if (_temp >= 0 && _temp < 6){
                            Direction = _temp + 2;
                            }
                        else if (_temp > 5){
                            Direction = _temp - 6;
                            }
                }
            }
        }
        public static class ResponseTime{
            public static double GetRelative(double delta){
                return 60 * delta;
                }

            }
    }