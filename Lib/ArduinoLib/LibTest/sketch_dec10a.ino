
#include <LiquidCrystal.h>

LiquidCrystal lcd(8, 9, 4, 5, 6, 7);
int count = 0;
int count_2 = 0;
String sensorId = "0";
long long currentTime = millis();
String message;
String command = "";
bool commandRead;

void setup() {
  lcd.begin(16, 2);
  Serial.begin(9600);
  commandRead = false;
}

void loop() {

  if (Serial.available())
  {

    lcd.clear();
    if ((sensorId = Serial.readStringUntil(':')).length() > 0)
    {
      if (sensorId == "1")
      {
        lcd.clear();
        lcd.print("Temp sensor");
        lcd.setCursor(0, 1);

        int sampleTime = Serial.readStringUntil(':').toInt();
        int samplingRate = Serial.readStringUntil(':').toInt();
        int priority = Serial.readStringUntil('\n').toInt();

        lcd.print(sampleTime);
        lcd.setCursor(5, 1);
        lcd.print(samplingRate);
        lcd.setCursor(10,1);
        lcd.print(priority);

        tempSensor(sampleTime, samplingRate);
      }

      if (sensorId=="2")
       {
        lcd.clear();
        lcd.print("Sound sensor");
        lcd.setCursor(0, 1);

        int sampleTime = Serial.readStringUntil(':').toInt();
        int samplingRate = Serial.readStringUntil(':').toInt();
        int priority = Serial.readStringUntil('\n').toInt();

        lcd.print(sampleTime);
        lcd.setCursor(5, 1);
        lcd.print(samplingRate);
        lcd.setCursor(10,1);
        lcd.print(priority);

        soundSensor(sampleTime, samplingRate);
      }
      
    }
  }
}


int tempSensor(int sampleTime, int samplingRate)
{

  int arraySize = sampleTime / samplingRate;

  int result[arraySize];

  for (int i = 0; i < arraySize; i++)
  {
    result[i] = random(25, 27);
    Serial.write(':');
    Serial.print(result[i]);
  }
  Serial.println();
}


int soundSensor(int sampleTime, int samplingRate)
{

  int arraySize = sampleTime / samplingRate;

  int result[arraySize];

  for (int i = 0; i < arraySize; i++)
  {
    result[i] = random(0, 2);
    Serial.write(':');
    Serial.print(result[i]);
  }
  Serial.println();
}

