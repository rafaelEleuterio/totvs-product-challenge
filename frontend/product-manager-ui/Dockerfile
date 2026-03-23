# Build Angular
FROM node:18 AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build -- --base-href / --deploy-url /


FROM nginx:alpine

RUN rm -rf /usr/share/nginx/html/*
# Serve com nginx
COPY --from=build /app/dist/product-manager-ui/browser /usr/share/nginx/html

EXPOSE 80