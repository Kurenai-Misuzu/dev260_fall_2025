// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// task1 calculate even numbers 1-100
// for loop
void forLoopCalculate(int number){
    int forLoopTotal = 0;
    if (number > 2000){
        Console.WriteLine("That's a big number!");
        return;
    }
    for (int i = 1; i <= number; i++){
        if ( i % 2 == 0){
            forLoopTotal += i;
        }
    }
    Console.WriteLine("for loop Total: " + forLoopTotal);
}

forLoopCalculate(100);


// while loop
void whileLoopCalculate(int number){
    int whileLoopTotal = 0;
    int whileCounter = 1;
    while (whileCounter <= number){
        if (whileCounter % 2 == 0){
            whileLoopTotal += whileCounter;
        }
        whileCounter++;
    }
    string result = (number > 2000) ? "That's a big number!" : "while loop Total: " + whileLoopTotal.ToString();
    Console.WriteLine(result);
}

whileLoopCalculate(100);

// foreach
void foreachCalculate(int number){
    switch (number){
        case > 2000:
            Console.WriteLine("That's a big number!");
            break;
        case <= 2000:
            int foreachTotal = 0;
            int[] list = Enumerable.Range(1, number).ToArray();
            foreach (int i in list){
                if (i % 2 == 0){
                    foreachTotal += i;
                }
            }
            Console.WriteLine("foreach Total: " + foreachTotal);
            break;
    }
}

foreachCalculate(100);

Console.WriteLine("it felt easiest to do the for loop for this problem");

// task 2 create method for grading

// if else 
char GetLetterGrade_If(int score){
    if (score < 60){
        return 'F';
    } else if (score >= 60 && score < 70 ) {
        return 'D';
    } else if (score >= 70 && score < 80 ) {
        return 'C';
    } else if (score >= 80 && score < 90 ) {
        return 'B';
    }
    return 'A';
}

// switch
char GetLetterGrade_Switch(int score){
    char grade = 'A';
    switch (score){
        case < 60:
            grade = 'F';
            break;
        case >= 60 and < 70:
            grade = 'D';
            break;
        case >= 70 and < 80:
            grade = 'C';
            break;
        case >= 80 and < 90:
            grade = 'B';
            break;
        case >= 90 and < 100:
            grade = 'A';
            break;
    }
    return grade;
}

int grade = 89;
Console.WriteLine("score: " + grade + " change in program");
Console.WriteLine("if else: " + GetLetterGrade_If(grade));
Console.WriteLine("switch case: " + GetLetterGrade_Switch(grade));
Console.WriteLine("personally i found it easier to do the if else but might be better to do the switch for longer cases");


// task3 modify the sum of even numbers method so when more than 2000 gets plugged in it writes that's a big number!

whileLoopCalculate(2001);
