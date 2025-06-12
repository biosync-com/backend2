const express = require('express');
const swaggerUi = require('swagger-ui-express');
const YAML = require('yamljs');

const app = express();
const port = process.env.PORT || 3000;

const swaggerDocument = YAML.load('./swagger.yaml');

app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocument));

app.get('/hello', (req, res) => {
  res.send('Olá do backend com Swagger!');
});

app.listen(port, () => {
  console.log(`Servidor rodando na porta ${port}`);
  console.log(`Swagger UI disponível em http://localhost:${port}/api-docs`);
});
