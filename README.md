# RabbitMQSample
Sample message queue system using RabbitMQ.
# What is the RabbitMQ?
RabbitMQ is a popular open-source message queue software that is written in Erlang. According to its website: “RabbitMQ is lightweight and easy to deploy on-premises and in the cloud.” It supports several API protocols such as AMQP, STOMP, MQTT and HTTP. Additionally, RabbitMQ supports a lot of the common programming languages and can run on different cloud environments and operating systems. But, how does RabbitMQ work? The next section will explain that.

This is sample RabbitMQ project. I used the scenario of adding employees to the system. You can use when you send the mail to user. For example after signup you added user to db and you wanna send activation message that user but something went wrong in SMTP service. You can use RabbitMQ and you don't keep the user waiting.
