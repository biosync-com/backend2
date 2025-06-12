const express = require('express');
const client = require('prom-client');

const app = express();
const register = client.register;

// Métrica: contador total de requisições HTTP
const totalHttpRequests = new client.Counter({
  name: 'total_http_requests',
  help: 'Total de requisições HTTP recebidas pelo servidor',
});

// Middleware para contar as requisições
app.use((req, res, next) => {
  totalHttpRequests.inc();
  next();
});

// Rota padrão só para teste
app.get('/', (req, res) => {
  res.send('Olá! Servidor rodando e monitorado pelo Prometheus.');
});

// Rota para expor as métricas do Prometheus
app.get('/metrics', async (req, res) => {
  try {
    res.set('Content-Type', register.contentType);
    const metrics = await register.metrics();
    res.end(metrics);
  } catch (ex) {
    res.status(500).end(ex);
  }
});

// Porta do servidor
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
  console.log(`Servidor rodando na porta ${PORT}`);
});
