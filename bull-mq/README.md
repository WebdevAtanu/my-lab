# BullMQ Demo Project

A simple demonstration of BullMQ, a Redis-based queue for Node.js.

## Prerequisites

- Node.js installed
- Redis server running on localhost:6379

## Installation

Dependencies are already installed. If you need to reinstall:

```bash
npm install
```

## Usage

### 1. Start Redis Server

Make sure Redis is running on your system:

```bash
# On Windows (if using Redis for Windows)
redis-server

# On Linux/Mac
redis-server
```

### 2. Start the Worker

In one terminal, start the worker that will process jobs:

```bash
npm run worker
```

The worker will wait for jobs to be added to the queue.

### 3. Add Jobs to the Queue

In another terminal, run the producer to add jobs:

```bash
npm run producer
```

This will add 5 sample jobs to the queue.

### 4. Watch the Processing

You should see the worker processing each job with a 1-second delay between jobs.

## Project Structure

- `producer.js` - Script that adds jobs to the queue
- `worker.js` - Script that processes jobs from the queue
- `package.json` - Project configuration with npm scripts

## What Happens

1. The producer creates a queue named "my-queue" and adds 5 jobs
2. Each job contains an ID, message, and timestamp
3. The worker listens for jobs on the same queue
4. When jobs are available, the worker processes them with a 1-second delay
5. The worker logs each job's progress and completion

## Stopping the Worker

Press `Ctrl+C` in the worker terminal to gracefully shut down the worker.

## Customization

You can modify:
- Number of jobs in `producer.js`
- Processing logic in `worker.js`
- Queue name and Redis connection settings in both files
- Processing delay by changing the timeout in `worker.js`