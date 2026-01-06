# 🖧 NetworkAgent

NetworkAgent is a lightweight C# console application that monitors Ethernet network interfaces and periodically pushes statistics (inbound/outbound bytes) to a REST API endpoint.

## 📌 Features
- Monitors all available network interfaces on the machine.
- Tracks inbound and outbound bytes every 2 seconds.
- Sends stats to a configurable API endpoint in JSON format.
- Logs activity to the console for real-time monitoring.

## 🛠️ Technologies Used
- **.NET Core / .NET Framework**
- **System.Net.NetworkInformation** for NIC statistics
- **HttpClient** for API communication
- **Newtonsoft.Json** for JSON serialization

## 🚀 Getting Started

### Prerequisites
- .NET SDK installed (version 6.0 or later recommended).
- A running API endpoint to receive stats (default: `https://localhost:44316/Network/PushStats`).

### Installation
Clone the repository:
```bash
git clone https://github.com/your-username/NetworkAgent.git
cd NetworkAgent

# 🖧 NetworkAgent

NetworkAgent is a lightweight C# console application that monitors Ethernet network interfaces and periodically pushes statistics (inbound/outbound bytes) to a REST API endpoint.

## 📌 Features
- Monitors all available network interfaces on the machine.
- Tracks inbound and outbound bytes every 2 seconds.
- Sends stats to a configurable API endpoint in JSON format.
- Logs activity to the console for real-time monitoring.

## 🛠️ Technologies Used
- **.NET Core / .NET Framework**
- **System.Net.NetworkInformation** for NIC statistics
- **HttpClient** for API communication
- **Newtonsoft.Json** for JSON serialization

## 🚀 Getting Started

### Prerequisites
- .NET SDK installed (version 6.0 or later recommended).
- A running API endpoint to receive stats (default: `https://localhost:44316/Network/PushStats`).

### Installation
Clone the repository:
```bash
git clone https://github.com/khujrat17/NetworkAgent.git
cd NetworkAgent


Build & Run
dotnet build
dotnet run


Configuration
By default, the agent posts data to:
https://localhost:44316/Network/PushStats


You can change this by editing the apiUrl variable in Program.cs.
📊 Example Output
Starting Ethernet Monitor Agent for: MY-PC
[01/02/2026 10:34:12] NIC=Ethernet, In=2048 B, Out=1024 B
[01/02/2026 10:34:14] NIC=Ethernet, In=512 B, Out=256 B


📡 JSON Payload Example
{
  "MachineName": "MY-PC",
  "Interface": "Ethernet",
  "InboundBytes": 2048,
  "OutboundBytes": 1024,
  "RecordedAt": "2026-01-02T10:34:12"
}


⚠️ Notes
- Ensure your API endpoint is running and accessible.
- Requires administrator privileges on some systems to access NIC statistics.
- The monitoring loop runs indefinitely until manually stopped.
📄 License
This project is licensed under the MIT License - see the LICENSE file for details

