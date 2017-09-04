# ThermalJig-Automation

This project aims to simplify the testing process by changing the way the technicians tests thermal equipment. Previously, the technician would manually adjust the temperature on the controller and time the process; however, with this project, the program would run the process automatically and all the technician will have to do is to set the parameters of the test.

The project is done in C# and connects to the controller via the Modbus Protocol (RS-232). A functional GUI is also implemented to display 2 graphs for testing purposes. The temperature of the thermal equipments are also automatically logged in to the computer.

The automation aspect of the project increased the efficiency of the tests by around 90%. Each thermal equipment usually needs 20~25 minutes to be tested, but that has been cut down by the program to around 2 minutes. At its busiest time, the lab requires testing of 100 equipments, which takes a little over 33 hours of operation non-stop. The programp cuts that time down to less than 4 hours.

Finally, some testing procedure and default test parameters have been modified to erase sensitive information.
