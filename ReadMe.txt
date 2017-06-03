http://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/

01) What is XOR operator? Using "^" symbol, removes flag from set
	days ^= Weekdays.Tuesday;
02) What is OR operator? Using "|" symbol, adds flag to set
	var days = Weekdays.Monday | Weekdays.Tuesday | Weekdays.Wednesday;
03) What is AND operator? Using "&" symbol, checks to see if flag is in set, you can use HasFlag method
	bool isTuesdayInSet = (days & Weekdays.Tuesday) == Weekdays.Tuesday;            
04) What is NOT operator? Using "~" symbol, acts like XOR. What it does is simply inverting all the bits of an integer. This can be useful, for instance, to unset a bit.