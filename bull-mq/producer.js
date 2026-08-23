const { Queue } = require('bullmq');
const IORedis = require('ioredis');

// Create a Redis connection
const connection = new IORedis({
  host: 'localhost',
  port: 6379,
});

// Create a queue
const myQueue = new Queue('my-queue', { connection });

async function addJobs() {
  console.log('Adding jobs to the queue...');

  // Add some sample jobs
  for (let i = 1; i <= 5; i++) {
    await myQueue.add('my-job', {
      id: i,
      message: `Job ${i}`,
      timestamp: new Date().toISOString(),
    });
    console.log(`Added job ${i}`);
  }

  console.log('All jobs added successfully!');
  
  // Close the connection
  await connection.quit();
  process.exit(0);
}

// Handle errors
process.on('unhandledRejection', (error) => {
  console.error('Error:', error);
  connection.quit();
  process.exit(1);
});

addJobs();