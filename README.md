# A Bill Splitter based on C#

This is a Bill splitter that can take payment billings from multi-payers for different tripes.

The Input format<br/>
The input can contains multiple trips.<br/>
In the beginning of each trip, it have a line containing a positive number n.<br/>
This n is the number of payers in this trip.<br/>

There is n following groups after this number.<br/>
Each one represents a payers, and each group begin with a line containing a positive number P.<br/>
P is the number of paid billings for this payers.<br/>
There are p following lines. Each line contains a decimal amount for billing amount.<br/>

The input will be end with a trip having 0 payers.

The Output<br/>
For each trip, output 1 line for each payers.<br/>
If the payer's payment less than group average, then payer need pay more and the amount is positive.<br/>
If the payer's payment more than group average, then payer need be paid, and the amount is negative.<br/>
Negative number is enclosed by brackets. Trips are separated by a blank line.<br/>

Sample Input:<br/>
3<br/>
2<br/>
20.00<br/>
30.00<br/>
4<br/>
25.00<br/>
40.00<br/>
5.00<br/>
6.00<br/>
3<br/>
2.00<br/>
20.00<br/>
10.00<br/>
2<br/>
2<br/>
15.00<br/>
38.00<br/>
2<br/>
10.50<br/>
8.65<br/>
0<br/>

Sample of Output<br/>
$2.67<br/>
($23.33)<br/>
$20.67<br/>

($16.92)<br/>
$16.93<br/>
