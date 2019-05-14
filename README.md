# Q&A High Distinction Project
## 1. Introduction:
This is a custom program for High Distinction task in the Object Orient Programming unit in Swinburne University.
The program is written in **C# programming language.**
The GUI of the program is customised by using **Gtk# 2.0 project**.

## 2. Motivation:
This custom program is **the Quenstion and Answer program** which can be used in many purposes. For example, Swinburne students can use it for measuring how well they understand Swinburne University. Another usedful purpose for parents is that they are able to know how well they understand their children. Furthermore, this custom program applies **the concept of mindsharing** to find the answer for the unknown question.

## 3. Description:
The program generates list of 5 questions attached with 4 choices for each question. The player needs to choose 1 answer for each question within 30 seconds. 

At the same time, the program generates 4 bots in the back-end which receive the same list of questions and answers. Each bot select the answer randomly 30 times. Then, it returns the highest occurrences and the percentage of correct times when the bot select the correct answer. This information will be sent to the central bot and this bot will need to proceed the given information before selecting the answer the each question.

For each question, if the answer is correct, the score will increase by 1. Otherwise, the score will decrease by 1. This score will be saved to the text file for the ranking purpose.
