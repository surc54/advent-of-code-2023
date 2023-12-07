using _07;
using _07.Models;
using Shared;

var lines ="input.txt".ReadFile().SplitByNewLine();

var hands = new HandParser().Parse(lines);
