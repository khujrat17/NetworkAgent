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
