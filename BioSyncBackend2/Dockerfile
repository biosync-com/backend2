FROM node:18-alpine

WORKDIR /app

# Copiar package.json e package-lock.json (se tiver)
COPY package.json package-lock.json* ./

RUN npm install

# Copiar o restante do código (server.js, swagger.yaml etc)
COPY . .

EXPOSE 3000

CMD ["npm", "start"]
