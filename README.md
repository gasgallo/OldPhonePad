# OldPhonePad
Keypad strokes to text

## The problem
Here is an old phone keypad with alphabetical letters, a backspace key, and a send button.
Each button has a number to identify it and pressing a button multiple times will cycle
through the letters on it allowing each button to represent more than one letter.
For example, pressing 2 once will return ‘A’ but pressing twicein succession will return ‘B’.
You must pause for a second in order to type two characters from the same button
after each other: “222 2 22” -> “CAB”.

![Example of an old phone keyboard](https://github.com/gasgallo/OldPhonePad/blob/main/old_phone_pad.png)

## Solution
Create a C# library to translate the key strokes of numbers of the keypad into a string.


Examples:
```
OldPhonePad(“33#”) => output: E
OldPhonePad(“227*#”) => output: B
OldPhonePad(“4433555 555666#”) => output: HELLO
OldPhonePad(“8 88777444666*664#”) => output: TURING
```

## Requirements
- a recent version of `.NET`

## Usage
Build the library:
```
dotnet build OldPhonePad
```

Run the sample application:
```
dotnet run --project SampleApp
```

Run unit tests:
```
dotnet test OldPhonePadTest
```