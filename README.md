#A Bill Splitter based on C#

This is a Bill splitter that can take payment billings from multi-payers for different tripes.

The Input format

The input can contains multiple trips. 
In the beginning of each trip, it have a line containing a positive number n.
This n is the number of payers in this trip.

There is n following groups after this number.
Each one represents a payers, and each group begin with a line containing a positive number P.
P is the number of paid billings for this payers.
There are p following lines.
Each line contains a decimal amount for billing amount.

The input will be end with a trip having 0 payers.

The Output

For each trip, output 1 line for each payers.

If the payer's payment less than group average, then payer need pay more and the amount is positive.

If the payer's payment more than group average, then payer need be paid, and the amount is negative. 

Negative number is enclosed by brackets.

Trips are separated by a blank line.

Sample Input:

3

2

20.00

30.00

4

25.00

40.00

5.00

6.00

3

2.00

20.00

10.00

2

2

15.00

38.00

2

10.50

8.65

0

Sample of Output

$2.67

($23.33)

$20.67


($16.92)

$16.93

