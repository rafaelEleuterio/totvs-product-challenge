# Build Angular
FROM node:18 AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build

# Serve com nginx
FROM nginx:alpine
COPY --from=build /app/dist/product-manager /usr/share/nginx/html