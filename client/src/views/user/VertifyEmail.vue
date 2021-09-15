<template>
  <div>
    <div>
      <router-link>
        <img src="../../assets/logo.png" />
      </router-link>
    </div>
    <a-form>
      <div>
        <h1>验证电子邮件地址</h1>
        <div>
          为验证您的email，我们向{{ email }}发送了一个代码<router-link
            >更改</router-link
          >
        </div>
      </div>
      <a-form-item label="请输入验证码">
        <a-input v-model:value="activateCode"> </a-input>
      </a-form-item>
      <a-form-item>
        <a-button @click="vertifyCode()"></a-button>
      </a-form-item>
      <a-form-item>
        <a-button type="link" @click="sendActivateCode()">重新发送</a-button>
      </a-form-item>
    </a-form>
  </div>
</template>
<script>
export default {
  props: ["user"],
  data() {
    return {
      email: "email",
      activateCode: "",
    };
  },
  methods: {
    sendActivateCode() {},
    vertifyCode() {},
  },
};
</script>