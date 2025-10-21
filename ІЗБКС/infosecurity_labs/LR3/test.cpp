#include <WiFi.h>
#include <PubSubClient.h>
#include <ArduinoJson.h>

const char* WIFI_SSID = "Wokwi-GUEST";
const char* WIFI_PASSWORD = "";

const char* MQTT_CLIENT_ID = "";
const char* MQTT_BROKER = "mqtt-dashboard.com";
const char* MQTT_USER = "";
const char* MQTT_PASSWORD = "";
const char* MQTT_TOPIC = "IoT";

WiFiClient espClient;
PubSubClient client(espClient);

const int photoresistorPin = 34;
const int trigerPin = 4;
const int echoPin = 2;
const int lightWarningBubblePin = 5;
bool turned = true;
bool alart = false;

void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message received on topic: ");
  Serial.println(topic);

  String message;
  for (int i = 0; i < length; i++) {
    message += (char)payload[i];
  }
  Serial.print("Payload: ");
  Serial.println(message);

  DynamicJsonDocument doc(256); 
  DeserializationError error = deserializeJson(doc, message);

  if (error) {
    Serial.print(F("Failed to parse JSON: "));
    Serial.println(error.c_str());
    return;
  }
  String stringtext = doc["Status"];
  if(stringtext == "off")
  {
    turned = false;
  }
  else if(stringtext == "on")
  {
    turned = true;
  }
}

void setup() {
  Serial.begin(115200);
  pinMode(photoresistorPin, INPUT);
  pinMode(trigerPin, OUTPUT);
  pinMode(echoPin, INPUT);
  pinMode(lightWarningBubblePin, OUTPUT);

  Serial.print("Connecting to WiFi");
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(100);
  }
  Serial.println(" Connected!");

  client.setServer(MQTT_BROKER, 1883);
  client.setCallback(callback);  

  Serial.print("Connecting to MQTT server... ");
  while (!client.connected()) {
    if (client.connect(MQTT_CLIENT_ID, MQTT_USER, MQTT_PASSWORD)) {
      Serial.println("Connected!");
      client.subscribe(MQTT_TOPIC); 
    } else {
      Serial.print("Failed, rc=");
      Serial.print(client.state());
      Serial.println(" Retrying in 5 seconds...");
      delay(5000);
    }
  }
}

void loop() {

  client.loop();  
  String message = "";

  if(analogRead(photoresistorPin) > 2000 && turned)
  {

    digitalWrite(lightWarningBubblePin,HIGH);
    digitalWrite(trigerPin,LOW);
    delay(2);
    digitalWrite(trigerPin,HIGH);
    delay(10);
    digitalWrite(trigerPin,LOW);
    long value = pulseIn(echoPin,HIGH);
    double meters = value/58;
    Serial.println(meters);
    if(meters > 200)
    {
      digitalWrite(lightWarningBubblePin,LOW);
      if(alart)
      {
        alart = false;
        message = "{\"Alert\":\"All Good!\"}";
        client.publish(MQTT_TOPIC, message.c_str());
      }
    }
    else 
    {
      alart = true;
      message = "{\"Alert\":\"Someone Close!\"}";
      client.publish(MQTT_TOPIC, message.c_str());
    }
  }
  else if (analogRead(photoresistorPin) > 2000)
  {

    message = "{\"Alert\":\"System disabled!\"}";
    client.publish(MQTT_TOPIC, message.c_str());
  }
  client.loop();  
  delay(1000);
}

