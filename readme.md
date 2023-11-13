### MassTransit and RabbitMQ

- This is simple project which shows communication between 2 microservices using RabbitMQ and MassTransit.

- OrderService publishes a message when order is placed.
Notification service listens to queue and processes this message.

- MassTransit wires things up using Contract (Model). It's important that both publisher and consumer use same contract.

<details>

<summary>Good to know</summary>

  -  Publisher publishes message to [Namespace.Model] exchange.
  - Message is routed to [QueueName] exchange.
  - Message is then routed to [QueueName] queue.
  - Consumer picks the message from queue. 

</details>

