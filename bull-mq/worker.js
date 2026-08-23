const { Worker } = require('bullmq');
const IORedis = require('ioredis');

// Create a Redis connection
const connection = new IORedis({
  host: 'localhost',
  port: 6379,
});

// Create a worker
const worker = new Worker(
  'my-queue',
  async (job) => {
    console.log(`Processing job ${job.id}:`, job.data);
    
    // Simulate some work
    await new Promise((resolve) => setTimeout(resolve, 1000));
    
    console.log(`Completed job ${job.id}`);
    
    return { result: `Processed ${job.data.message}` };
  },
  { connection }
);

// Handle worker events
worker.on('completed', (job) => {
  console.log(`Job ${job.id} completed!`);
});

worker.on('failed', (job, err) => {
  console.error(`Job ${job?.id} failed with error:`, err.message);
});

worker.on('error', (err) => {
  console.error('Worker error:', err);
});

console.log('Worker is running and waiting for jobs...');

// Graceful shutdown
process.on('SIGINT', async () => {
  console.log('\nShutting down worker...');
  await worker.close();
  await connection.quit();
  process.exit(0);
});