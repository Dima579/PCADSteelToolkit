Greetings

Thankyou for viewing this project

This project is a plugin for ProgeCAD 2026 created with a C# class library that creates 5 different section types from an SQLlite file, it was created for a technical task and won't recieve any updates.

Pre-requisites removed from source control and need installing for project to work:
- Teigha .NET SDK
- IntelliCAD runtime assemblies

It uses the following frameworks:
- .NET Framework 4.8
- Dapper ORM
- SQLlite Core

How to use this plugin:
1. Open the .sln of the project and compile the project into a .dll (the keyboard shortcut is Ctrl + Shift + B), once compiled you can find the file in PCADSteelToolkit -> bin -> debug
2. Initialise a new/existing project in ProgeCAD
3. Go to tools and click Command Prompt
4. In the text box, type NETLOAD and open the .dll file previously compiled
5. use one of 5 commands as defined below

The commands as follows:
- GenerateHFCHSection => Requires an Outside Diameter and Thickness Designation value
- GenerateHFRHSection => Requires a HB Size and Thickness Designation value
- GenerateLUNEQSection => Requires a Section Designation Outside Diameter value
- GenerateUBUCSection => Requires a Section Type, Section Designation and Mass Designation value
- GenerateSectionShorthand => Requires a Section Type, and 2 other values (values specific to the type of section)

Please additionally note values MUST be inputted identically to structure as seen in the SQLlite file and values below (You can find the file in the Data folder of the main directory or in bin -> Debug -> Data once compiled)

For example values please see below (for all values except the shorthand, please disregard the | as it's used to only seperate the individual values):

For HFCH:      For HFRH:            For LUNEQ:        For UB:              For UC:                For Shorthand:
42.4 |	3.2    50  x  30 |	3.2     200x150 |	18.0    610 x 178 |	x 100    356 x 406 |	x 1299	  HFCH/42.4/3.2
60.3 |	3.6    60  x  40 |	8.0     150x90 | 10.0     533 x 210 |	x 138    356 x 368 |	x 177     HFRH/50  x  30/3.2
114.3 |	5.0    100  x  60 |	6.3     100x75 |	12.0    533 x 312 |	x 151    254 x 254 |	x 107     LUNEQ/200x150/18.0
244.5 |	16.0   150  x  100 |	4.0   70x50 |	6.0       762 x 267 |	x 173    203 x 203 |	x 52      UB/610 x 178/x 100
457.0 |	14.2   500  x  200 |	17.5  30x20 |	3.0       457 x 191 |	x 89     152 x 152 |	x 23      UC/356 x 406/x 1299
