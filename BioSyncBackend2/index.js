const express = require('express');
const swaggerUi = require('swagger-ui-express');
const YAML = require('yamljs');

const app = express();
const port = 3000;

// Carregue seu arquivo Swagger YAML (crie swagger.yaml na raiz)
const swaggerDocument = YAML.load('./swagger.yaml');

// Serve o Swagger UI na rota /api-docs
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocument));
app.listen(3000, () => {
  console.log('Servidor rodando em http://localhost:3000');
});

