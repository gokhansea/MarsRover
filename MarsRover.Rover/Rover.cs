using MarsRover.Entity;
using MarsRover.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        private int _sizeX;
        private int _sizeY;
        private int _x;
        private int _y;
        private int _direction;

        public Dictionary<int, Position> movement;

        public Rover(int geoSizeX, int geoSizeY)
        {
             
            _sizeX = geoSizeX;
            _sizeY = geoSizeY;
            movement = MovementInit();
        }

        public RoverStatus Move(int startX, int startY, string direction,string directive)
        {
            RoverStatus result = new RoverStatus();
            result.IsError = false;
            try
            {
                _x = startX;
                _y = startY;

                #region validation

                if (_sizeX < _x || _sizeY < _y)
                {
                    result.IsError = true;
                    result.Message = "Start position error!";
                }

                else if (!MoveValidation(directive))
                {
                    result.IsError = true;
                    result.Message = "Directive error!";
                }


                #endregion
                else
                {
                    _direction = (int)(DirectiveEnums)Enum.Parse(typeof(DirectiveEnums), direction);

                    foreach (var item in directive)
                    {
                        MovementEnums move = (MovementEnums)Enum.Parse(typeof(MovementEnums), item.ToString());

                        if (move == MovementEnums.M)
                        {
                            //hareket
                            _x += movement[_direction].x;
                            _y += movement[_direction].y;
                            _x = Math.Min(_x, _sizeX);
                            _y = Math.Min(_y, _sizeY);
                        }
                        else
                        {
                            //yön belirleme
                            _direction += (int)move;
                            _direction = _direction > 3 ? _direction - 4 : _direction;
                            _direction = _direction < 0 ? 4 + _direction : _direction;
                        }
                    }

                    result.Position.x = _x;
                    result.Position.y = _y;
                    result.Position.direction = ((DirectiveEnums)_direction);
                }
            }
            catch(Exception ex)
            {
                result.IsError = true;
                result.Message = $"An error has occurred! Detail: {ex.Message}";
            }
            return result;

        }

        private Dictionary<int, Position> MovementInit()
        {
            Dictionary<int, Position> yonle = new Dictionary<int, Position>();

            //0 north
            yonle.Add((int)DirectiveEnums.N, new Position{x = 0,y = 1,});
            //east
            yonle.Add((int)DirectiveEnums.E, new Position{x = 1,y = 0,});
            //sourth
            yonle.Add((int)DirectiveEnums.S, new Position{x = 0,y = -1,});
            //west
            yonle.Add((int)DirectiveEnums.W, new Position{x = -1,y = 0,});

            return yonle;
        }

        private bool MoveValidation(string directive)
        {
            foreach (var item in directive)
            {
                if (!Enum.IsDefined(typeof(MovementEnums), item.ToString())) return false;
            }
            return true;
        }
    }
}
