using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge.BusinessLogic.interfaces;

internal interface IToyRobotCommandService
{
    void Command(string command);
}
