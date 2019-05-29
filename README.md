# MyQA Project
## 1. Introduction:
The MyQA game is my custom program for High Distinction task in Object Oriented Programming unit (COS20007) in Swinburne University.

Programming language: 
* **C#.Net Framework v4.7.0**
* **Gtk-Sharp v2.4.0**

Unit testing framwork: **UNit**

IDE: **Visual Studio 2019**

## 2. Motivation:
The MyQA game is the **Question and Answer game** which can be used in many purposes. For example, Swinburne students can use it for measuring how ell they understand their university. Another useful purpose is that parents are able to know how well they understand their children. In regard to technical motivation, I would like to apply **object oriented principles**, which I learned from the university, and the **basic concept of neural network**, which I self-taught, into a question and answer game.

## 3. Description:
This game is the **Question and Answer game**, so it genrates the list of 5 questions - each question has 4 choices which are arranged in the random order. The topic of the question can be schooling, computer science, machine learning, etc.

To play the game, the player firstly has to enter his/her name and then choose the mode of the bot s/he wants to compete with. There are 3 modes, including easy, medium and hard. In the end of the game, the score of the player will be showed on the screen and that is used for comparing to the score of the bot. In addition, the player is able to play again or exit after s/he has been finished the match.

The bot is being contructed after the player select the mode of the bot. It has **number of neurons which depends on the selected mode**. For example, if that is the easy mode, the bot will be constructed with 10% of the total number of neurons. Each neuron has the information of 5 questions. For each question, **the neuron selects randomly the choice and then computes the score for that based on the correction**. After every neuron is computed, **the bot will select the neuron which has the highest score** and that is the final score of it.

For each question, if the selected choice is correct, the **score** will increase by 1. Otherwise, the score will decrease by 1. **If the player has not selected the choice within 30 seconds, the score will decrease by 1**. If the player clicks on the play again button in the end of the game, the score will reset by 0.

The player's name and his/her score will be saved to the **text file** in the end of the game. If the player's name exists and the current score is higher than the previous score, it will override the previous score. This feature is ensure that **the data about the player is not duplicated**

## 4. Demo:
![alt text](https://github.com/peterdu98/MyQA/blob/master/demo/OpeningScreen.png "The title screen of the game")
![alt text](https://github.com/peterdu98/MyQA/blob/master/demo/HistoryScreen.png "The history screen of the game")
![alt text](https://github.com/peterdu98/MyQA/blob/master/demo/ModeScreen%20(old).png "The mode screen of the game")
![alt text](https://github.com/peterdu98/MyQA/blob/master/demo/QuestionScreen.png "The question screen of the game")
![alt text](https://github.com/peterdu98/MyQA/blob/master/demo/ResultScreen(win).png "The result screen of the game")
