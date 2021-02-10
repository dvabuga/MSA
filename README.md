# MSA
Task:
Write a program that would print all possible distinct permutations of a given string. String can contain repeating letters. All distinc permutations should be displayed only once.
Estimate time and space complexity

To solve the task i have used Narayana algorithm.
This algorithm has a complexity estimate - O(n). Since we are looping through all the elements of the line.
The best case is when the penultimate element of the permutation is greater than the last, then 2 comparisons and 1 exchange are made. 
The worst case is when the permutation elements are sorted in descending order.
To estimate the speed of the algorithm, I used the class Stopwatch.
