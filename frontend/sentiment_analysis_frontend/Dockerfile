FROM node:24-alpine as base
EXPOSE 3000
WORKDIR /app

COPY package*.json ./

FROM base as builder
WORKDIR /app
RUN npm install
COPY . .
RUN npm run build


FROM base as production
WORKDIR /app

ENV NODE_ENV=production
RUN addgroup -g 1001 -S nodejs
RUN adduser -S nextjs -u 1001
USER nextjs


COPY --from=builder --chown=nextjs:nodejs /app/.next ./.next
COPY --from=builder /app/node_modules ./node_modules
COPY --from=builder /app/package.json ./package.json
COPY --from=builder /app/public ./public

ENTRYPOINT ["npm", "start"]