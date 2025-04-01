void setup() {
	//set up a serial connection for debug printing
	Serial.begin(9600); 
}

void loop() {
  //read in the analog input on analog pin 1
  int val = analogRead(A1);
  //print to the console
  Serial.println(val);
}

