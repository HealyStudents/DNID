void setup() {
  pinMode(7, OUTPUT);
  pinMode(4, INPUT);
}

void loop() {
  int val = digitalRead(4);
  digitalWrite(7, val);
}

