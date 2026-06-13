class emailService {
    sendEmail(email, subject, message) {
        console.log(`Sending email to ${email} with subject "${subject}" and message "${message}"`); // log the email sending
    }
}

export default new emailService;